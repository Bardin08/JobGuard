export interface VacancyReport {
  fraudRiskScore: number;
  companyVerified: boolean;
  vacancyDetails: VacancyDetails;
  companyInfo: CompanyDetails;
  redFlags: RedFlag[];
  verificationDate: Date;
}

export interface VacancyDetails {
  jobTitle: string;
  companyName: string;
  jobDescription: string;
  jobLocation: string;
  salaryRange?: string;
  employmentType?: string;
  postedDate: Date;
  applicationDeadline?: Date;
  dataSources?: string[];
}

export interface CompanyDetails {
  name: string;
  industry: string;
  companySize?: string;
  companyWebsite?: string;
  companyDescription?: string;
  legalDetails?: CompanyLegalDetails;
  socialMediaLinks: string[];
  financialData: FinancialData;
  complianceStatus: ComplianceStatus;
  employeeReviewRating?: number;
  employeeReview?: EmployeeReview;
  dataSources: string[];
}

export interface CompanyLegalDetails {
  registrationNumber?: string;
  incorporateDate?: string;
  registeredAddress?: string;
}

export interface FinancialData {
  annualRevenue?: string;
  profitability?: string;
}

export interface ComplianceStatus {
  complianceIssues?: string;
  litigationHistory?: string;
  sanctionsCheck?: string;
}

export interface EmployeeReview {
  reviewSource: string;
  rating: number;
  review: string;
}

export interface RedFlag {
  name: string;
  shortDescription: string;
  longDescription: string;
  severity: SeverityLevel;
  riskReductionStrategy: RiskReductionStrategy;
}

export interface RiskReductionStrategy {
  strategyType: string;
  description: string;
}

export enum SeverityLevel {
  Low = 'Low',
  Medium = 'Medium',
  High = 'High',
  Critical = 'Critical'
}
