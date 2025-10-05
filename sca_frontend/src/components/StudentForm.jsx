// src/components/StudentForm.jsx
import React, { useState, useEffect } from 'react';

const StudentForm = ({ onSave, studentToEdit }) => {
  const [name, setName] = useState('');
  const [age, setAge] = useState('');
  const [course, setCourse] = useState('');

  useEffect(() => {
    if (studentToEdit) {
      setName(studentToEdit.name);
      setAge(studentToEdit.age);
      setCourse(studentToEdit.course);
    }
  }, [studentToEdit]);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!name || !age || !course) return;

    const newStudent = { name, age, course, id: studentToEdit?.id };
    onSave(newStudent);

    setName('');
    setAge('');
    setCourse('');
  };

  return (
    <form onSubmit={handleSubmit} className="student-form">
      <input
        type="text"
        placeholder="Name"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <input
        type="number"
        placeholder="Age"
        value={age}
        onChange={(e) => setAge(e.target.value)}
      />
      <input
        type="text"
        placeholder="Course"
        value={course}
        onChange={(e) => setCourse(e.target.value)}
      />
      <button type="submit">{studentToEdit ? 'Update' : 'Add'} Student</button>
    </form>
  );
};

export default StudentForm;
