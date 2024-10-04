using JobGuard.Domain.Primitives;

namespace JobGuard.Domain.Entities;

public class VacancyDetails : Entity
{
    private readonly List<string> _responsibilities;
    private readonly List<string> _qualifications;
    private readonly List<string> _dataSources;

    private VacancyDetails(
        Guid id,
        string jobTitle,
        string jobDescription,
        string? jobLocation,
        string? salaryRange,
        string? employmentType,
        DateTimeOffset postedDate,
        DateTimeOffset? applicationDeadline,
        List<string> responsibilities,
        List<string> qualifications,
        Guid companyId) : base(id)
    {
        JobTitle = jobTitle;
        JobLocation = jobLocation;
        SalaryRange = salaryRange;
        EmploymentType = employmentType;
        PostedDate = postedDate;
        ApplicationDeadline = applicationDeadline;
        JobDescription = jobDescription;
        CompanyId = companyId;
        _responsibilities = responsibilities;
        _qualifications = qualifications;

        _dataSources = [];
    }

    #region Properties

    public string JobTitle { get; private set; }

    public string? JobLocation { get; private set; }

    public string? SalaryRange { get; private set; }

    public string? EmploymentType { get; private set; }

    public string JobDescription { get; private set; }

    public IReadOnlyList<string> Responsibilities => _responsibilities;
    public IReadOnlyList<string> Qualifications => _qualifications;

    public DateTimeOffset PostedDate { get; private set; }

    public DateTimeOffset? ApplicationDeadline { get; private set; }

    public IReadOnlyList<string> DataSources => _dataSources;

    public Guid CompanyId { get; private set; }

    #endregion

    #region Methods

    public static VacancyDetails Create(
        string jobTitle,
        string jobDescription,
        string? jobLocation,
        string? salaryRange,
        string? employmentType,
        DateTimeOffset postedDate,
        DateTimeOffset? applicationDeadline,
        List<string> responsibilities,
        List<string> qualifications,
        Guid companyId)
    {
        return new VacancyDetails(
            Guid.NewGuid(),
            jobTitle,
            jobDescription,
            jobLocation,
            salaryRange,
            employmentType,
            postedDate,
            applicationDeadline,
            responsibilities,
            qualifications,
            companyId);
    }

    public void AddSource(string dataSource)
    {
        if (string.IsNullOrEmpty(dataSource))
            throw new ArgumentNullException(nameof(dataSource));

        if (Uri.IsWellFormedUriString(dataSource, UriKind.Absolute))
            _dataSources.Add(dataSource);
        else if (Enum.TryParse<DataSourceType>(dataSource, ignoreCase: true, out var dataSourceType))
            _dataSources.Add(dataSourceType.ToString());
        else throw new ArgumentException(nameof(dataSource));
    }

    #endregion
}

public enum DataSourceType
{
    ProvidedDescription
}