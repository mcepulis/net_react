import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Navbar from '../Navbar'; 

interface HighScore {
  id: number;
  email: string;
  score: number;
  dateTime: string;
}

const HighScoresPage: React.FC = () => {
  const [highScores, setHighScores] = useState<HighScore[]>([]);

  useEffect(() => {
    const fetchHighScores = async () => {
      try {
        const response = await axios.get('https://localhost:7235/api/quiz/high-scores');
        setHighScores(response.data);
      } catch (error) {
        console.error('Error fetching high scores:', error);
      }
    };

    fetchHighScores();
  }, []);

  return (
    <div className="bg-gray-100">
      <Navbar />
      <div className="min-h-screen bg-gray-100 flex justify-center p-4">
        <div className="bg-white shadow-lg rounded-lg w-full max-w-3xl p-8">
          <h1 className="text-3xl font-bold text-center mb-6">High Scores</h1>
          <table className="min-w-full table-auto">
            <thead>
              <tr>
                <th className="px-4 py-2 text-left">Rank</th>
                <th className="px-4 py-2 text-left">Email</th>
                <th className="px-4 py-2 text-left">Score</th>
              </tr>
            </thead>
            <tbody>
              {highScores.map((score, index) => {
                let rowClass = '';
                if (index === 0) rowClass = 'bg-yellow-400'; 
                else if (index === 1) rowClass = 'bg-gray-300'; 
                else if (index === 2) rowClass = 'bg-orange-300'; 

                return (
                  <tr key={score.id} className={`border-t ${rowClass}`}>
                    <td className="px-4 py-2">{index + 1}</td>
                    <td className="px-4 py-2">{score.email}</td>
                    <td className="px-4 py-2">{score.score}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default HighScoresPage;
