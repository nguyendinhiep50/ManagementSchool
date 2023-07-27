import React, { useState, useEffect } from "react";
import {} from "@ant-design/icons";
import type { MenuProps } from "antd";
import { Layout, theme, Col, Row } from "antd";
import NavbarManagement from "./NavbarManagement";
import InFomationAccount from "../Management/InfomationAccount.tsx";
import ImageInfomation from "../Management/ImageInfomation.tsx";

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
            <h1>hiển thị</h1>
            <Row>
              <Col span={12}>
                <ImageInfomation />
              </Col>
              <Col span={12}>
                <InFomationAccount />
              </Col>
            </Row>
          </Content>
        </Layout>
      </Layout>
    </>
  );
}
export default ManagementStudent;
