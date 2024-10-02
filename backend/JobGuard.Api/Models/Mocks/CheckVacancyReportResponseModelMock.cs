using JobGuard.Api.Models.VacancyCheck.Reports;

namespace JobGuard.Api.Models.Mocks;

internal static class CheckVacancyReportResponseModelMock
{
    public static CheckVacancyReportResponseModel GoodVacancy =>
        new(
            VacancyDetailsViewModel: new VacancyDetailsViewModel(
                JobTitle: "Principal/Lead .NET Developer",
                JobDescription:
                "Lead and architect .NET solutions, mentor team members, and work on complex software development projects in a dynamic environment.",
                JobLocation: "Ukraine (remote)",
                SalaryRange: "Competitive (not disclosed)",
                EmploymentType: "Full-time",
                PostedDate: "2024-09-30",
                ApplicationDeadline: null, // Not specified
                CompanyName: "Intellias",
                SourcePlatforms: ["Intellias Career Page", "LinkedIn", "DOU.ua"]
            ),
            CompanyInfoViewModel: new CompanyInfoViewModel(
                Name: "Intellias",
                Industry: "Software Development",
                CompanySize: "5001-10,000 employees",
                CompanyDescription:
                "Leading IT services provider, working with clients in various industries to deliver custom software solutions.",
                CompanyWebsite: "https://intellias.com",
                RegistrationNumber: "123456789",
                IncorporationDate: "2002-03-10",
                RegisteredAddress: "Lviv, Ukraine",
                SocialMedia: new SocialMediaViewModel(LinkedIn: "https://www.linkedin.com/company/intellias",
                    Facebook: "https://www.facebook.com/intellias"),
                FinancialData: new FinancialDataViewModel(AnnualRevenue: "100M+", Profitability: true),
                ComplianceStatus: null,
                Rating: 4.6,
                Reviews: ["Great work environment", "Strong career growth opportunities"],
                Source: "Glassdoor, DOU.ua"
            ),
            Qualifications: new QualificationsViewModel(
                EducationRequirements: ["Bachelor’s or Master’s degree in Computer Science or related field"],
                ExperienceRequirements:
                [
                    "8+ years of experience in .NET development", "Proven leadership experience"
                ],
                Skills: [".NET 8", "C#", "Azure", "Microservices architecture", "CI/CD pipelines"],
                Certifications: ["Microsoft Certified: Azure Developer Associate"]
            ),
            CompensationDetails: new CompensationDetailsViewModel(
                SalaryRange: "Competitive (not disclosed)",
                Benefits: ["Medical insurance", "Flexible work hours", "Remote work"],
                BonusStructure: "Performance-based bonuses",
                EquityOptions: null // Not mentioned
            ),
            CompanyReputation: new CompanyReputationViewModel(
                EmployeeReviews:
                [
                    new EmployeeReviewViewModel(
                        ReviewSource: "Glassdoor",
                        Rating: 4.6,
                        Reviews: ["Intellias is a great place for career development"]
                    )
                ],
                PublicFlags: ["Positive work-life balance", "Great leadership"]
            ),
            VacancyVerificationViewModel: new VacancyVerificationViewModel(
                Verified: true,
                FraudScore: 0,
                VerifiedBy: "JobGuard",
                VerificationDate: DateOnly.FromDateTime(DateTime.Now),
                CrossCheckedPlatforms: ["LinkedIn", "DOU.ua"],
                RedFlags: null
            ),
            TechnicalData: new TechnicalDataViewModel(
                PostedBy: new PostedByViewModel(Name: "HR Manager", Email: "hr@intellias.com", Phone: "+380671234567"),
                PostingType: "Manual",
                LastUpdated: DateTimeOffset.Now
            )
        );

    public static CheckVacancyReportResponseModel BadVacancy =>
        new(
            VacancyDetailsViewModel: new VacancyDetailsViewModel(
                JobTitle: "Senior .NET Developer",
                JobDescription:
                "Seeking an experienced .NET developer for a fast-paced project with tight deadlines. Responsibilities include backend development and maintaining legacy code.",
                JobLocation: "Remote (Unknown country)",
                SalaryRange: "$1000 - $1500 per month (below market average)",
                EmploymentType: "Contract-based (3 months)",
                PostedDate: "2024-09-15",
                ApplicationDeadline: "2024-10-15",
                CompanyName: "XYZ Tech Solutions",
                SourcePlatforms: ["Unknown Job Portal", "LinkedIn", "Random Forum"]
            ),
            CompanyInfoViewModel: new CompanyInfoViewModel(
                Name: "XYZ Tech Solutions",
                Industry: "Unknown (possibly fraudulent)",
                CompanySize: "1-10 employees (questionable)",
                CompanyDescription:
                "A newly established tech solutions company claiming to work with international clients but with no verifiable track record.",
                CompanyWebsite: "http://xyztech.fakewebsite.com",
                RegistrationNumber: null,
                IncorporationDate: null,
                RegisteredAddress: null,
                SocialMedia: new SocialMediaViewModel(
                    LinkedIn: null,
                    Facebook: null
                ),
                FinancialData: new FinancialDataViewModel(
                    AnnualRevenue: null,
                    Profitability: false
                ),
                ComplianceStatus: new ComplianceStatusViewModel(
                    ComplianceIssues: "Company has been flagged for fraudulent activities.",
                    LitigationHistory: "Multiple legal disputes with former employees.",
                    SanctionsCheck: "Listed under international sanctions."
                ),
                Rating: 1.2,
                Reviews:
                [
                    "Avoid this company! They don't pay salaries on time.",
                    "Terrible work environment with unethical practices."
                ],
                Source: "DOU.ua, Glassdoor"
            ),
            Qualifications: new QualificationsViewModel(
                EducationRequirements: ["High school diploma or equivalent"],
                ExperienceRequirements: ["2+ years of .NET development"],
                Skills: ["Basic C#", "Minimal SQL knowledge", "Legacy .NET Framework experience"],
                Certifications: null
            ),
            CompensationDetails: new CompensationDetailsViewModel(
                SalaryRange: "$1000 - $1500 per month",
                Benefits: ["None", "Unpaid overtime expected"],
                BonusStructure: "None",
                EquityOptions: null
            ),
            CompanyReputation: new CompanyReputationViewModel(
                EmployeeReviews:
                [
                    new EmployeeReviewViewModel(
                        ReviewSource: "Glassdoor",
                        Rating: 1.2,
                        Reviews:
                        [
                            "The company is a scam. I worked for 3 months and never got paid.",
                            "Horrible management. They have no idea how to run projects."
                        ]
                    )
                ],
                PublicFlags: ["Flagged for fraud on multiple forums", "Reported for not paying employees"]
            ),
            VacancyVerificationViewModel: new VacancyVerificationViewModel(
                Verified: false,
                FraudScore: 85,
                VerifiedBy: "JobGuard",
                VerificationDate: DateOnly.FromDateTime(DateTime.Now),
                CrossCheckedPlatforms: ["LinkedIn", "Random Forum"],
                RedFlags:
                [
                    new RedFlagViewModel(
                        Name: "Fake Website",
                        ShortDescription: "Company website is not operational or trustworthy.",
                        LongDescription:
                        "The provided company website leads to a non-functional or highly suspicious domain, casting doubt on the legitimacy of the business.",
                        Severity: SeverityLevel.High,
                        RiskReductionStrategy: new RiskReductionStrategyViewModel(
                            StrategyType: "Manual Review",
                            Description:
                            "Recommend further investigation by checking the website’s domain registration and cross-referencing it with legitimate sources."
                        )
                    ),
                    new RedFlagViewModel(
                        Name: "Unpaid Salaries",
                        ShortDescription: "Reports of unpaid employee salaries.",
                        LongDescription:
                        "Multiple employees have reported delayed or non-payment of salaries over a prolonged period.",
                        Severity: SeverityLevel.Critical,
                        RiskReductionStrategy: new RiskReductionStrategyViewModel(
                            StrategyType: "Cross-Check",
                            Description:
                            "Check forums like DOU.ua, Glassdoor, and Indeed for additional employee reviews and payment reports."
                        )
                    ),
                    new RedFlagViewModel(
                        Name: "Missing Legal Information",
                        ShortDescription: "Company lacks verifiable registration data.",
                        LongDescription:
                        "There is no legal or registration information available for the company, suggesting it may not be a legitimate business.",
                        Severity: SeverityLevel.Critical,
                        RiskReductionStrategy: new RiskReductionStrategyViewModel(
                            StrategyType: "Verification via Business Registries",
                            Description:
                            "Conduct a manual check of local and international business registries to confirm company authenticity."
                        )
                    )
                ]
            ),
            TechnicalData: new TechnicalDataViewModel(
                PostedBy: new PostedByViewModel(
                    Name: "Unknown Recruiter",
                    Email: "recruiter@xyztech.fakeemail.com",
                    Phone: "123456789"
                ),
                PostingType: "Manual",
                LastUpdated: DateTimeOffset.Now
            )
        );
}