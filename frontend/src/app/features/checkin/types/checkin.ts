export interface CreateCheckInDto {
  employeeId: string;
  mood: number;  
  score: number;
  comment?: string;
}

export interface CheckInResponse {
  id: string;
  employeeId: string;
  mood: number;
  score: number;
  comment?: string;
  date: string;
}