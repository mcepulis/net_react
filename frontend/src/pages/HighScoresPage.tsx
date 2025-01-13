import React, { useEffect, useState } from 'react';
import axios from 'axios';

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
      const response = await axios.get('https://localhost:7235/api/quiz/high-scores');
      setHighScores(response.data);
    };

    fetchHighScores();
  }, []);

  return (
    <div>
      <h1>High Scores</h1>
      <table>
        <thead>
          <tr>
            <th>Position</th>
            <th>Email</th>
            <th>Score</th>
            <th>Date</th>
          </tr>
        </thead>
        <tbody>
          {highScores.map((score, index) => (
            <tr key={score.id} style={{
              backgroundColor: index === 0 ? 'gold' :
                               index === 1 ? 'silver' :
                               index === 2 ? 'bronze' : 'transparent'
            }}>
              <td>{index + 1}</td>
              <td>{score.email}</td>
              <td>{score.score}</td>
              <td>{new Date(score.dateTime).toLocaleString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default HighScoresPage;
