import React, { useState } from "react";
import {
  LaptopOutlined,
  NotificationOutlined,
  UserOutlined,
} from "@ant-design/icons";
import type { MenuProps } from "antd";

import { Layout, Menu, theme } from "antd";

import { useLocation, Link } from "react-router-dom";
const { Sider } = Layout;

const items1: MenuProps["items"] = [
  "Tài khoản",
  "Teacher Student",
  "Quản lý chương trình",
].map((key, index) => ({
  key,
  label: `${key}`,
  ArrayList: generateArrayList(key),
}));
function generateArrayList(key) {
  if (key === "Tài khoản") {
    return [
      { key: "ManagementStudent", value: "Thông tin tài khoản" },
      { key: "ChangePassword", value: "Đổi mật khẩu" },
    ];
  } else if (key === "Teacher Student") {
    return [
      { key: "AddStudent", value: "Thêm học sinh" },
      { key: "ListStudent", value: "Danh sách học sinh" },
      { key: "AddTeacher", value: "Thêm giảng viên" },
      { key: "ListTeacher", value: "Danh sách giảng viên" },
    ];
  } else if (key === "Quản lý chương trình") {
    return [
      { key: "ManagementHK", value: "quản lý học kì" },
      { key: "ManagementClass", value: "quản lý lớp" },
      { key: "ManagementSubject", value: "quản lý môn học" },
      { key: "ManagementCourses", value: "quản lý khóa học" },
    ];
  }
}
const items2: MenuProps["items"] = [
  UserOutlined,
  LaptopOutlined,
  NotificationOutlined,
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
