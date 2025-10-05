import React from 'react';

const StudentCard = ({ student, onDelete, onEdit }) => {
  return (
    <div className="student-card">
      <h3>{student.name}</h3>
      <p>Age: {student.age}</p>
      <p>Course: {student.course}</p>
      <div className="card-buttons">
        <button onClick={() => onEdit(student)}>Edit</button>
        <button onClick={() => onDelete(student.id)}>Delete</button>
      </div>
    </div>
  );
};

export default StudentCard;
