using FluentValidation;
using HtmlAgilityPack;
using JobGuard.Application.Abstractions.Messaging;
using JobGuard.Application.Models.DataCollection;

namespace JobGuard.Application.DataCollection.Commands;

public record FetchDataFromLinkCommand(
    string Url,
    bool CollectLinks,
    bool AsPlainText
) : ICommand<LinkContentDto>;

public class FetchDataFromLinkCommandValidator : AbstractValidator<FetchDataFromLinkCommand>
{
    public FetchDataFromLinkCommandValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Url is required")
            .Must(l => Uri.IsWellFormedUriString(l, UriKind.Absolute)).WithMessage("Invalid URL");
    }
}

public class FetchDataFromLinkCommandHandler : ICommandHandler<FetchDataFromLinkCommand, LinkContentDto>
{
    public Task<LinkContentDto> Handle(FetchDataFromLinkCommand request, CancellationToken cancellationToken)
    {
        var web = new HtmlWeb();
        var document = web.Load(request.Url);

        var collectLinks = new List<string>();
        if (request.CollectLinks)
        {
            var links = document.DocumentNode.SelectNodes("//a[@href]")
                ?.Select(node => node.GetAttributeValue("href", string.Empty))
                .Where(href => !Uri.IsWellFormedUriString(href, UriKind.Absolute))
                .ToList() ?? Enumerable.Empty<string>();

            collectLinks.AddRange(links);
        }

        var dto = new LinkContentDto
        {
            Url = request.Url,
            CollectedLinks = collectLinks,
            Content = request.AsPlainText ? document.DocumentNode.InnerText : document.DocumentNode.OuterHtml
        };

        return Task.FromResult(dto);
    }
}