namespace JobGuard.Infrastructure.Services.OpenAi;

internal static class Prompts
{
    public static string GetVacancyDetailsRequetsPrompt(string vacancyDescription)
        => ParseVacancyDetailsPromptTemplate.Replace("{{ vacancy_description }}", vacancyDescription);

    private const string ParseVacancyDetailsPromptTemplate =
        """
        Extract the following information from the provided job vacancy description and return it as a JSON object formatted in PascalCase. The JSON should match the structure of the VacancyDto class.

        Response format should look like this:
        VacancyDto class structure:
        {
            "JobTitle": string,
            "JobLocation": string (optional, null if not specified),
            "SalaryRange": string (optional, null if not specified),
            "EmploymentType": string (optional, null if not specified),
            "JobDescription": string (summary of description),
            "PostedDate": string (in ISO 8601 format, null if not specified),
            "ApplicationDeadline": string (optional, in ISO 8601 format, null if not specified),
            "Responsibilities": list of strings (optional, empty if not specified),
            "Qualifications": list of strings (optional, emply if not specified)
        }

        Summarize the job description to focus on the main responsibilities, required skills, and key details, limiting the summary to 3-4 sentences.

        Job Description:
        "{{ vacancy_description }}"

        Response format must look like this, and only the JSON object itself:
        
        {
            "JobTitle": "Strong Middle Backend Developer (Python, routers)",
            "JobLocation": "віддалено",
            "SalaryRange": null,
            "EmploymentType": null,
            "JobDescription": "Our client is one of the premier communications services’ providers... (rest of description)",
            "PostedDate": "2024-10-04T00:00:00Z",
            "ApplicationDeadline": null,
            "Responsibilities": [],
            "Qualifications": []
        }
        
        Only return the JSON object without any additional formatting or text.
        Now, generate the JSON in camelCase.
        """;
}