import React, { useState, useEffect } from "react";
import {} from "@ant-design/icons";
import type { MenuProps } from "antd";
import { Layout, theme, Col, Row } from "antd";
import NavbarManagement from "./NavbarManagement";
import AddStudent from "../Management/AddStudent.tsx";

function ManagementStudent() {
  const { Content } = Layout;
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  return (
    <>
      <Layout>
        <NavbarManagement />
        <Layout style={{ padding: "0 24px 24px" }}>
          <Content
            style={{
              padding: "0 24px",
              margin: 0,
              minHeight: 280,
              background: colorBgContainer,
            }}
          >
            <h1>Add Student</h1>
            <AddStudent />

            <Row></Row>
          </Content>
        </Layout>
      </Layout>
    </>
  );
}
export default ManagementStudent;