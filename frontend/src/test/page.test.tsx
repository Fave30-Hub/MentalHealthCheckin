/// <reference types="@testing-library/jest-dom" />
import { render, screen } from '@testing-library/react';
import HomePage from '@/app/page';
import * as checkInHooks from '@/app/features/checkin/hooks/useCheckIn';

jest.mock('@/app/features/checkin/hooks/useCheckIn', () => ({
  useCreateCheckIn: jest.fn(),
  useCheckIns: jest.fn(),
}));

describe('pageload', () => {
  beforeEach(() => {
    jest.clearAllMocks();

    (checkInHooks.useCreateCheckIn as jest.Mock).mockReturnValue({
      mutate: jest.fn(),
      isPending: false,
    });

    (checkInHooks.useCheckIns as jest.Mock).mockReturnValue({
      data: [],
      isLoading: false,
      isError: false,
    });
  });

  // it('page', () => {
  //   render(<HomePage />);
  //   expect(screen.getByText(/Mental Health Check-In/i)).toBeInTheDocument();
  // });

  // it('input', () => {
  //   render(<HomePage />);
  //   expect(screen.getByPlaceholderText(/Mood/i)).toBeInTheDocument();
  //   expect(screen.getByPlaceholderText(/Score/i)).toBeInTheDocument();
  //   expect(screen.getByPlaceholderText(/Comment/i)).toBeInTheDocument();
  // });

  // it('list check-ins', () => {
  //   render(<HomePage />);
  //   expect(screen.getByText(/No check-ins yet/i)).toBeInTheDocument();
  // });

});