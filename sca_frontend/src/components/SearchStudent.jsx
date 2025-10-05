// src/components/SearchStudent.jsx
import React, { useState } from 'react';
import { getStudentById } from '../services/api'; // Import the API method

const SearchStudent = () => {
  const [studentId, setStudentId] = useState(''); // Store the student ID
  const [studentData, setStudentData] = useState(null); // Store the student data
  const [error, setError] = useState(''); // Store the error message

  // Handle search on button click
  const handleSearch = async () => {
    if (!studentId) {
      setError('Please enter a student ID.');
      setStudentData(null);
      return;
    }

    try {
      const data = await getStudentById(studentId); // Fetch the student by ID
      setStudentData(data);
      setError('');
    } catch (err) {
      setError('Student not found or an error occurred.');
      setStudentData(null);
    }
  };

  return (
    <div className="search-student">
      <h2>Search for Student by ID</h2>
      <div className="search-input">
        <input
          type="number"
          placeholder="Enter Student ID"
          value={studentId}
          onChange={(e) => setStudentId(e.target.value)} // Update ID as user types
        />
        <button onClick={handleSearch}>Search</button>
      </div>

      {/* Show error if no student ID is entered or if an error occurs */}
      {error && <p className="error">{error}</p>}

      {/* Show student details if found */}
      {studentData && (
        <div className="student-result">
          <h3>Student Details</h3>
          <p><strong>Name:</strong> {studentData.name}</p>
          <p><strong>Age:</strong> {studentData.age}</p>
          <p><strong>Course:</strong> {studentData.course}</p>
        </div>
      )}
    </div>
  );
};

export default SearchStudent;
