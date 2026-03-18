import { api } from "@/lib/api";
import { CreateCheckInDto, CheckInResponse } from "../types/checkin";

    //Post
export const createCheckIn = async (data: CreateCheckInDto): Promise<CheckInResponse> => {
  const response = await api.post<CheckInResponse>("/checkin", data);
  return response.data;
};

    //Get
export const getCheckIns = async (): Promise<CheckInResponse[]> => {
  const response = await api.get<CheckInResponse[]>("/checkin");
  return response.data;
};