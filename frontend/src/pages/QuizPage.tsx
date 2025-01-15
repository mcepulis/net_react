import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Navbar from '../Navbar';
import { useNavigate } from 'react-router-dom';

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
  const navigate = useNavigate()

  useEffect(() => {
    const fetchQuestions = async () => {
      const response = await axios.get('https://localhost:7235/api/quiz/questions');
      setQuestions(response.data);
    };

    fetchQuestions();
  }, []);

  const handleAnswerChange = (questionId: number, selectedAnswerIds: number[], textAnswer: string) => {
    setAnswers((prevAnswers) => [
      ...prevAnswers.filter((answer) => answer.QuestionId !== questionId),
      { QuestionId: questionId, SelectedAnswerIds: selectedAnswerIds, TextAnswer: textAnswer },
    ]);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (!email) {
      alert('Please enter your email before submitting the quiz.');
      return;
    }

    try {
      const response = await axios.post('https://localhost:7235/api/quiz/submit-quiz', {
        Email: email,
        Answers: answers,
      });

      alert(`Quiz submitted! Your score: ${response.data.score}`);

      setEmail(''); 
      setAnswers([]); 
      
      const formElements = document.querySelectorAll('input[type="checkbox"], input[type="radio"], input[type="text"]');
      formElements.forEach((el) => {
        (el as HTMLInputElement).checked = false;
        (el as HTMLInputElement).value = '';
      });

      try {
        navigate('/high-scores');
      } catch (error) {
        console.error('Navigation error:', error);
      }

    } catch (error) {
      console.error('Error submitting quiz:', error);
    }
  };

  return (
    <div className="bg-gray-100">
      <Navbar />
      <div className="min-h-screen bg-gray-100 flex justify-center p-4">
        <div className="bg-white shadow-lg rounded-lg w-full max-w-3xl p-8">
          <h1 className="text-3xl font-bold text-center mb-6">Quiz</h1>
          <form onSubmit={handleSubmit} className="space-y-6">
            <div>
              <input
                type="email"
                placeholder="Enter your email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                className="w-full px-4 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>
            {questions.map((question) => (
              <div key={question.id} className="space-y-4">
                <h3 className="text-xl font-semibold">{question.questionText}</h3>
                {question.questionType === 'Radio' &&
                  question.answers.map((answer) => (
                    <div key={answer.id} className="flex items-center space-x-2">
                      <input
                        type="radio"
                        name={question.id.toString()}
                        value={answer.id}
                        onChange={(e) =>
                          handleAnswerChange(question.id, [parseInt(e.target.value)], '')
                        }
                        className="h-4 w-4"
                      />
                      <label className="text-lg">{answer.text}</label>
                    </div>
                  ))}
                {question.questionType === 'Checkbox' &&
                  question.answers.map((answer) => (
                    <div key={answer.id} className="flex items-center space-x-2">
                      <input
                        type="checkbox"
                        value={answer.id}
                        onChange={(e) => {
                          const selected = e.target.checked
                            ? [...(answers.find((a) => a.QuestionId === question.id)?.SelectedAnswerIds || []), answer.id]
                            : (answers.find((a) => a.QuestionId === question.id)?.SelectedAnswerIds || []).filter(
                                (id) => id !== answer.id
                              );
                          handleAnswerChange(question.id, selected, '');
                        }}
                        className="h-4 w-4"
                      />
                      <label className="text-lg">{answer.text}</label>
                    </div>
                  ))}
                {question.questionType === 'Textbox' && (
                  <input
                    type="text"
                    placeholder="Your answer"
                    onChange={(e) => handleAnswerChange(question.id, [], e.target.value)}
                    className="w-full px-4 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                  />
                )}
              </div>
            ))}
            <div className="flex justify-center">
              <button
                type="submit"
                className="px-6 py-3 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500"
              >
                Submit Quiz
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default QuizPage;
