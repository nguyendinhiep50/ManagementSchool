import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import LoginAccount from "./Component/LoginAccount";
import IndexStudent from "./Views/Student/IndexStudent";

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/" exact component={LoginAccount} />
        <Route path="/IndexStudent" exact component={IndexStudent} />
        {/* Add other routes here if needed */}
      </Switch>
    </Router>
  );
}

export default App;
