// src/services/api.js
import axios from 'axios';

const BASE_URL = 'http://localhost:5141/api/students'; // Backend URL

export const getStudents = async () => {
  try {
    const response = await axios.get(BASE_URL);
    return response.data;
  } catch (error) {
    console.error("Error fetching students:", error);
    throw error;
  }
};

export const addStudent = async (student) => {
  try {
    const response = await axios.post(BASE_URL, student);
    return response.data;
  } catch (error) {
    console.error("Error adding student:", error);
    throw error;
  }
};

export const updateStudent = async (student) => {
  try {
    const response = await axios.put(`${BASE_URL}/${student.id}`, student);
    return response.data;
  } catch (error) {
    console.error("Error updating student:", error);
    throw error;
  }
};

export const deleteStudent = async (id) => {
  try {
    await axios.delete(`${BASE_URL}/${id}`);
  } catch (error) {
    console.error("Error deleting student:", error);
    throw error;
  }
};

export const getStudentById = async (id) => {
  try {
    const response = await axios.get(`${BASE_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching student with ID ${id}:`, error);
    throw error;
  }
};