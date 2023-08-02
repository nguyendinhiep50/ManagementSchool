import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

import LoginAccount from "./Component/LoginAccount";
import ManagementStudent from "./Views/Management/ManagementStudent";
import ChangePassword from "./Views/Management/ChangePassword";
import AddStudent from "./Views/Management/TeacherStudent/AddStudent";
import ListStudent from "./Views/Management/TeacherStudent/ListStudent";
import AddTeacher from "./Views/Management/TeacherStudent/AddTeacher";
import ListTeacher from "./Views/Management/TeacherStudent/ListTeacher";

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
    </Router>
  );
}

export default App;
