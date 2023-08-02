import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

import LoginAccount from "./Component/LoginAccount";
import ManagementStudent from "./Views/Management/ManagementStudent";
import ChangePassword from "./Views/Management/ChangePassword";
import AddStudent from "./Views/Management/TeacherStudent/AddStudent";
import ListStudent from "./Views/Management/TeacherStudent/ListStudent";
import AddTeacher from "./Views/Management/TeacherStudent/AddTeacher";
import ListTeacher from "./Views/Management/TeacherStudent/ListTeacher";
import AddSemester from "./Views/Management/SemesterSubjectFaculty/AddSemester";
import ListSemester from "./Views/Management/SemesterSubjectFaculty/ListSemester";
import AddFaculty from "./Views/Management/SemesterSubjectFaculty/AddFaculty";
import ListFaculty from "./Views/Management/SemesterSubjectFaculty/ListFaculty";
import AddSubject from "./Views/Management/SemesterSubjectFaculty/AddSubject";
import ListSubject from "./Views/Management/SemesterSubjectFaculty/ListSubject";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginAccount />}></Route>
      </Routes>
      <Routes>
        <Route path="/ManagementStudent" element={<ManagementStudent />} />
      </Routes>
      <Routes>
        <Route path="/ChangePassword" element={<ChangePassword />} />
      </Routes>
      <Routes>
        <Route path="/AddStudent" element={<AddStudent />} />
      </Routes>
      <Routes>
        <Route path="/ListStudent" element={<ListStudent />} />
      </Routes>
      <Routes>
        <Route path="/AddTeacher" element={<AddTeacher />} />
      </Routes>
      <Routes>
        <Route path="/ListTeacher" element={<ListTeacher />} />
      </Routes>
      <Routes>
        <Route path="/ListTeacher" element={<ListTeacher />} />
      </Routes>

      <Routes>
        <Route path="/AddSemester" element={<AddSemester />} />
      </Routes>
      <Routes>
        <Route path="/ListSemester" element={<ListSemester />} />
      </Routes>
      <Routes>
        <Route path="/AddFaculty" element={<AddFaculty />} />
      </Routes>
      <Routes>
        <Route path="/ListFaculty" element={<ListFaculty />} />
      </Routes>
      <Routes>
        <Route path="/AddSubject" element={<AddSubject />} />
      </Routes>
      <Routes>
        <Route path="/ListSubject" element={<ListSubject />} />
      </Routes>
    </Router>
  );
}

export default App;
