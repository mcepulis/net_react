import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface Answer {
  id: number;
  text: string;
  isCorrect: boolean;
}

interface QuizQuestion {
  id: number;
  questionText: string;
  questionType: string;
  answers: Answer[];
}

interface UserAnswer {
  QuestionId: number;
  SelectedAnswerIds: number[];
  TextAnswer: string;
}

const QuizPage: React.FC = () => {
  const [questions, setQuestions] = useState<QuizQuestion[]>([]);
  const [email, setEmail] = useState('');
  const [answers, setAnswers] = useState<UserAnswer[]>([]);

  useEffect(() => {
    const fetchQuestions = async () => {
      const response = await axios.get('https://localhost:7235/api/quiz/questions');
      setQuestions(response.data);
    };

    fetchQuestions();
  }, []);

  const handleAnswerChange = (questionId: number, selectedAnswerIds: number[], textAnswer: string) => {
    setAnswers(prevAnswers => [
      ...prevAnswers.filter(answer => answer.QuestionId !== questionId),
      { QuestionId: questionId, SelectedAnswerIds: selectedAnswerIds, TextAnswer: textAnswer }
    ]);
  };

  const handleSubmit = async () => {
    try {
      const response = await axios.post('https://localhost:7235/api/quiz/submit-quiz', {
        Email: email,
        Answers: answers,
      });
      alert(`Quiz submitted! Your score: ${response.data.score}`);
    } catch (error) {
      console.error("Error submitting quiz:", error);
    }
  };

  return (
    <div>
      <h1>Quiz Page</h1>
      <input
        type="email"
        placeholder="Enter your email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />
      <form onSubmit={handleSubmit}>
        {questions.map((question) => (
          <div key={question.id}>
            <h3>{question.questionText}</h3>
            {question.questionType === "Radio" && (
              question.answers.map((answer) => (
                <div key={answer.id}>
                  <input
                    type="radio"
                    name={question.id.toString()}
                    value={answer.id}
                    onChange={(e) => handleAnswerChange(question.id, [parseInt(e.target.value)], '')}
                  />
                  <label>{answer.text}</label>
                </div>
              ))
            )}
            {question.questionType === "Checkbox" && (
              question.answers.map((answer) => (
                <div key={answer.id}>
                  <input
                    type="checkbox"
                    value={answer.id}
                    onChange={(e) => {
                      const selected = e.target.checked
                        ? [...answers.find(a => a.QuestionId === question.id)?.SelectedAnswerIds || [], answer.id]
                        : (answers.find(a => a.QuestionId === question.id)?.SelectedAnswerIds || []).filter((id) => id !== answer.id);

                      handleAnswerChange(question.id, selected, '');
                    }}
                  />
                  <label>{answer.text}</label>
                </div>
              ))
            )}
            {question.questionType === "Textbox" && (
              <input
                type="text"
                placeholder="Your answer"
                onChange={(e) => handleAnswerChange(question.id, [], e.target.value)}
              />
            )}
          </div>
        ))}
        <button type="submit">Submit Quiz</button>
      </form>
    </div>
  );
};

export default QuizPage;
