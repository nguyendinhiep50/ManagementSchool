import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import LoginAccount from "./Component/LoginAccount";
import IndexStudent from "./Views/Student/IndexStudent.js";
import RegisterSubject from "./Views/Student/RegisterSubject.js";

import IndexTeacher from "./Views/Teacher/IndexTeacher.js";

import IndexManagement from "./Views/Management/IndexManagement.js";
import StudentManagement from "./Views/Management/StudentManagement.js";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginAccount></LoginAccount>} />
      </Routes>
      {/* Student */}
      <Routes>
        <Route path="/IndexStudent" element={<IndexStudent />}></Route>
      </Routes>
      <Routes>
        <Route path="/ChangePassword" element={<IndexStudent />}></Route>
      </Routes>
      <Routes>
        <Route path="/IndexTeacher" element={<IndexTeacher />}></Route>
      </Routes>
      <Routes>
        <Route path="/RegisterSubject" element={<RegisterSubject />}></Route>
      </Routes>
      {/* Management */}
      <Routes>
        <Route path="/IndexManagement" element={<IndexManagement />}></Route>
      </Routes>
      <Routes>
        <Route
          path="/StudentManagement"
          element={<StudentManagement />}
        ></Route>
      </Routes>
    </Router>
  );
}

export default App;
