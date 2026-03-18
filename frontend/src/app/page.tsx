'use client';

import { useState } from 'react';
import { v4 as uuidv4 } from 'uuid';
import { useCreateCheckIn, useCheckIns, CheckInDto  } from '@/app/features/checkin/hooks/useCheckIn';
import toast from 'react-hot-toast';

export default function HomePage() {
  const { data: checkIns, refetch, isLoading: isListLoading, isError: isListError } = useCheckIns();

  const createCheckInMutation = useCreateCheckIn();

  const [form, setForm] = useState({
    employeeId: '',
    mood: '',
    score: '',
    comment: '',
  });

  const handleSubmit = () => {
  if (!form.employeeId) {
    toast.error('Employee Name is required', {
    position: 'top-center',
  });
    return;
  }

  const moodValue = form.mood ? Number(form.mood) : 2;
  const scoreValue = form.score ? Number(form.score) : 3;

  createCheckInMutation.mutate(
    { ...form, mood: moodValue, score: scoreValue },
    {
      onSuccess: () => {
        toast.success('Check-in submitted!', {
          position: 'top-center',
        });
        setForm({ employeeId: '', mood: '', score: '', comment: '' });
        refetch();
      },
      onError: (error: any) => {
        toast.error(error?.response?.data?.message || 'Failed to submit check-in', {
          position: 'top-center',
        });
      },
    }
  );
};

  return (
    <div className="min-h-screen bg-gray-100 p-8">
      <div className="max-w-2xl mx-auto bg-white p-6 rounded-2xl shadow-lg">
        <h1 className="text-3xl font-bold mb-6 text-center text-gray-800">Mental Health Check-In</h1>

        {/* Form */}
        <div className="space-y-4">

  {/* Employee Name */}
  <div>
    <label className="block font-medium text-gray-700 mb-1">Employee Name</label>
    <input
      type="text"
      className="border rounded-lg p-3 w-full focus:outline-none focus:ring-2 focus:ring-blue-400"
      placeholder="Enter Employee Name"
      value={form.employeeId}
      onChange={(e) => setForm({ ...form, employeeId: e.target.value })}
    />
  </div>

  {/* Mood and Score */}
  <div className="flex gap-4">
    <div className="flex-1">
      <label className="block font-medium text-gray-700 mb-1">Mood (1-Sad, 2-Neutral, 3-Happy)</label>
      <input
        type="number"
        min={1}
        max={3}
        className="border rounded-lg p-3 w-full focus:outline-none focus:ring-2 focus:ring-blue-400"
        placeholder="Enter Mood (1-3)"
        value={form.mood}
        onChange={(e) => setForm({ ...form, mood: e.target.value })}
        onBlur={() => {
          const num = Number(form.mood);
          if (num < 1) setForm({ ...form, mood: '1' });
          else if (num > 3) setForm({ ...form, mood: '3' });
        }}
      />
    </div>

    <div className="flex-1">
      <label className="block font-medium text-gray-700 mb-1">Score (1-5)</label>
      <input
        type="number"
        min={1}
        max={5}
        className="border rounded-lg p-3 w-full focus:outline-none focus:ring-2 focus:ring-blue-400"
        placeholder="Enter Score (1-5)"
        value={form.score}
        onChange={(e) => setForm({ ...form, score: e.target.value })}
        onBlur={() => {
          const num = Number(form.score);
          if (num < 1) setForm({ ...form, score: '1' });
          else if (num > 5) setForm({ ...form, score: '5' });
        }}
      />
    </div>
  </div>

  {/* Comment */}
  <div>
    <label className="block font-medium text-gray-700 mb-1">Comment</label>
    <input
      type="text"
      className="border rounded-lg p-3 w-full focus:outline-none focus:ring-2 focus:ring-blue-400"
      placeholder="Enter Comment"
      value={form.comment}
      onChange={(e) => setForm({ ...form, comment: e.target.value })}
    />
  </div>

  <div className="flex justify-center mt-4">
  <button
    type="button"
    onClick={handleSubmit}
    className="bg-blue-500 hover:bg-blue-600 text-white font-semibold py-2 px-6 rounded-lg shadow"
  >
    Submit Check-In
  </button>
</div>

</div>
      </div>

      {/* Check-in List */}
      <div className="max-w-2xl mx-auto mt-8 space-y-4">
        <h2 className="text-2xl font-semibold text-gray-700 mb-4">Submitted Check-Ins</h2>

        {isListLoading && <p className="text-gray-500">Loading check-ins...</p>}
        {isListError && <p className="text-red-500">Failed to load check-ins.</p>}

        {!isListLoading && checkIns?.length === 0 && (
          <p className="text-gray-500">No check-ins yet.</p>
        )}

        {checkIns?.map((c: CheckInDto) => (
  <div key={c.id} className="bg-white rounded-xl shadow p-4 flex justify-between items-center">
    <div>
      <p className="font-semibold text-gray-800">Employee: {c.employeeId.slice(0, 8)}</p>
      <p>Mood: {c.mood} | Score: {c.score}</p>
      <p className="text-gray-500 text-sm">{c.comment || 'N/A'}</p>
    </div>
    <div className="text-gray-400 text-xs">
      {new Date(c.date).toLocaleString('en-US', {
        dateStyle: 'medium',
        timeStyle: 'short',
      })}
    </div>
  </div>
))}
      </div>
    </div>
  );
}