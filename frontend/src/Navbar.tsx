import React from 'react';
import { Link } from 'react-router-dom';

const Navbar: React.FC = () => {
  return (
    <nav className="bg-blue-600 shadow-lg">
      <div className="max-w-7xl mx-auto px-4">
        <div className="flex justify-center items-center h-16 space-x-20 pr-8 ml-16">
          <Link to="/" className="text-white text-lg font-semibold hover:text-blue-200 transition-colors">
            Quiz
          </Link>
          <Link to="/high-scores" className="text-white text-lg font-semibold hover:text-blue-200 transition-colors">
            High Scores
          </Link>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
