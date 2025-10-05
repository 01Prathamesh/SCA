// src/App.jsx
import React, { useState } from 'react';
import StudentForm from './components/StudentForm';
import StudentList from './components/StudentList';
import { addStudent, updateStudent } from './services/api';
import './App.css';

const App = () => {
  const [studentToEdit, setStudentToEdit] = useState(null);

  const handleSaveStudent = async (student) => {
    try {
      if (student.id) {
        await updateStudent(student); // Update student if editing
      } else {
        await addStudent(student); // Add new student
      }
      setStudentToEdit(null); // Reset editing state
    } catch (error) {
      console.error('Error saving student:', error);
    }
  };

  const handleEditStudent = (student) => {
    setStudentToEdit(student); // Set student data for editing
  };

  return (
    <div className="app">
      <h1>Student Management</h1>
      <StudentForm onSave={handleSaveStudent} studentToEdit={studentToEdit} />
      <StudentList onEdit={handleEditStudent} />
    </div>
  );
};

export default App;
