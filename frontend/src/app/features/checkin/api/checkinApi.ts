import api from './api'; // points to api.ts

export interface CheckInForm {
  employeeId: string;
  mood: number;
  score: number;
  comment?: string;
}

export const createCheckIn = async (data: CheckInForm) => {
  const response = await api.post('/checkin', data);
  return response.data;
};

export const getCheckIns = async () => {
  const response = await api.get('/checkin');
  return response.data;
};