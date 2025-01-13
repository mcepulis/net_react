import React from "react";
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";
import QuizPage from './pages/QuizPage';
import HighScoresPage from './pages/HighScoresPage';

function App() {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Quiz</Link>
            </li>
            <li>
              <Link to="/high-scores">High Scores</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<QuizPage />} />
          <Route path="/high-scores" element={<HighScoresPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
