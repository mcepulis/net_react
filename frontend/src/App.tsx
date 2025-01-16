import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import QuizPage from './pages/QuizPage';
import HighScoresPage from './pages/HighScoresPage';

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <Routes>
          <Route path="/" element={<QuizPage />} />
          <Route path="/high-scores" element={<HighScoresPage />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
