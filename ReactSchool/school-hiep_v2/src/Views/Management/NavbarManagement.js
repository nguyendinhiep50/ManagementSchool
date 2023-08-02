import React, { useState } from "react";
import {
  LaptopOutlined,
  NotificationOutlined,
  UserOutlined,
  ReadOutlined,
  DatabaseOutlined,
} from "@ant-design/icons";
import type { MenuProps } from "antd";

import { Layout, Menu, theme } from "antd";

import { useLocation, Link } from "react-router-dom";
const { Sider } = Layout;

const items1: MenuProps["items"] = [
  "Account",
  "Teacher Student",
  "Semesters,Subject,Faculty",
  "Class learn",
].map((key, index) => ({
  key,
  label: `${key}`,
  ArrayList: generateArrayList(key),
}));
function generateArrayList(key) {
  if (key === "Account") {
    return [
      { key: "ManagementStudent", value: "Thông tin tài khoản" },
      { key: "ChangePassword", value: "Đổi mật khẩu" },
    ];
  } else if (key === "Teacher Student") {
    return [
      { key: "AddStudent", value: "Add Student" },
      { key: "AddTeacher", value: "Add Teacher" },
      { key: "ListStudent", value: "List Student" },
      { key: "ListTeacher", value: "List Teacher" },
    ];
  } else if (key === "Semesters,Subject,Faculty") {
    return [
      { key: "AddSemester", value: "Add Semester" },
      { key: "AddFaculty", value: "Add Faculty" },
      { key: "AddSubject", value: "Add Subject" },
      { key: "ListSemester", value: "List Semester" },
      { key: "ListFaculty", value: "List Faculty" },
      { key: "ListSubject", value: "List Subject" },
    ];
  } else if (key === "Class learn") {
    return [
      { key: "AddStudent_Class", value: "Add Student Class" },
      { key: "AddClassLearn", value: "Add Class Learn" },
      { key: "ListStudent_Class", value: "List Student Class" },
      { key: "ListClassLearn", value: "List Class Learn" },
    ];
  }
}
const items2: MenuProps["items"] = [
  UserOutlined,
  LaptopOutlined,
  DatabaseOutlined,
  ReadOutlined,
  // OneToOneOutlined,
  // ExperimentOutlined,
].map((icon, index) => {
  const key = String(items1[index].label);
  const arrayList = items1[index].ArrayList;
  return {
    key: `sub${key}`,
    icon: React.createElement(icon),
    label: `${key}`,
    children: arrayList.map((item) => {
      return {
        label: <Link to={`/${item.key}`}>{item.value}</Link>,
      };
    }),
  };
});

const IndexStudent: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  const [collapsed, setCollapsed] = useState(false);
  return (
    <Sider
      width={200}
      style={{ background: colorBgContainer }}
      trigger={null}
      collapsible
      collapsed={collapsed}
    >
      <Menu
        mode="inline"
        defaultSelectedKeys={["1"]}
        defaultOpenKeys={["sub1"]}
        style={{ height: "100%", borderRight: 0 }}
        items={items2}
      ></Menu>
    </Sider>
  );
};

export default IndexStudent;
