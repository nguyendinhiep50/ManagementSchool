import React, { useState, useEffect } from "react";
import ListTeacher from "./ListTeacher.tsx";
import {} from "@ant-design/icons";
import type { MenuProps } from "antd";
import { Layout, theme, Col, Row } from "antd";
import NavbarManagement from "./NavbarManagement";

function ListStudent() {
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
            <h1>Add teacher</h1>
            <ListTeacher />

            <Row></Row>
          </Content>
        </Layout>
      </Layout>
    </>
  );
}
export default ListStudent;
