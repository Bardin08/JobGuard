using System.Text.Json;
using JobGuard.Application.Abstractions.Services;
using JobGuard.Application.Models.Vacancies;
using OpenAI.Chat;

namespace JobGuard.Infrastructure.Services.OpenAi;

public class OpenAiService(ChatClient chatClient) : IOpenAiService
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly ChatClient _chatClient = chatClient;

    public async Task<VacancyDto> GetVacancyFromDescription(string description, CancellationToken cancellationToken)
    {
        var prompt = Prompts.GetVacancyDetailsRequetsPrompt(description);
        var response = await _chatClient.CompleteChatAsync(prompt);
        
        var message = new AssistantChatMessage(response);
        var vacancyDetails = JsonSerializer.Deserialize<VacancyDto>(message.Content[0].Text, JsonSerializerOptions);

        if (vacancyDetails is null)
            throw new Exception($"Failed to get vacancy DTO from: {description}");

        return vacancyDetails;
    }
}