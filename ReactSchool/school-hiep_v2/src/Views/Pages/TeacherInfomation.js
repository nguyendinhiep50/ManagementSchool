import React from "react";
import {
  LaptopOutlined,
  NotificationOutlined,
  UserOutlined,
  MenuFoldOutlined,
  MenuUnfoldOutlined,
} from "@ant-design/icons";

import { Breadcrumb, Layout, Menu, theme, Button, Col, Row } from "antd";

import HeaderContent from "../../Component/HeaderContent";
import ImageInfomation from "../Teacher/ImageInfomation.tsx";
const { Header, Content, Sider } = Layout;
function TeacherInfomation() {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  return (
    <>
      <Layout>
        <Layout style={{ padding: "0 24px 24px" }}>
          <HeaderContent></HeaderContent>

          <Content
            style={{
              padding: "24px 24px 0 24px",
              margin: 0,
              minHeight: 280,
              background: colorBgContainer,
            }}
          >
            <Row>
              <Col span={12}>
                <ImageInfomation />
              </Col>
              {/* <Col span={12}>
                {ChangePassword == false ? (
                  <InfomationAccount />
                ) : (
                  <ChangePassword />
                )}
              </Col> */}
            </Row>
          </Content>
        </Layout>
      </Layout>
    </>
  );
}
export default TeacherInfomation;
