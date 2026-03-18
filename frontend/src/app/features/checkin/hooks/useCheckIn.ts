import { useMutation, useQuery } from '@tanstack/react-query';
import { createCheckIn, getCheckIns, CheckInForm } from '../api/checkinApi';

export interface CheckInDto {
  id: string;
  employeeId: string;
  date: string;
  mood: number;
  score: number;
  comment?: string | null;
}

export const useCreateCheckIn = () => {
  return useMutation<any, Error, CheckInForm>({
    mutationFn: (data: CheckInForm) => createCheckIn(data),
  });
};

export const useCheckIns = () => {
  return useQuery<CheckInDto[]>({
    queryKey: ['checkIns'],
    queryFn: getCheckIns,
    refetchOnWindowFocus: false,
  });
};

//export type { CheckInForm } from '../api/checkinApi';