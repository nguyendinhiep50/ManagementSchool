import React, { useState, useEffect } from "react";
import {
  LaptopOutlined,
  NotificationOutlined,
  UserOutlined,
  MenuFoldOutlined,
  MenuUnfoldOutlined,
} from "@ant-design/icons";
import type { MenuProps } from "antd";

import { Breadcrumb, Layout, Menu, theme, Button, Col, Row } from "antd";
import InfomationAccount from "./InfomationAccount.tsx";
import ImageInfomation from "./ImageInfomation.tsx";
import ChangePassword from "./ChangePassword.tsx";
import RegisterSubject from "./RegisterSubject.tsx";
import { useLocation, Link } from "react-router-dom";
const { Header, Content, Sider } = Layout;

const items1: MenuProps["items"] = ["Tài khoản", "Đăng ký môn", "Lịch"].map(
  (key, index) => ({
    key,
    label: `${key}`,
    ArrayList: generateArrayList(key),
  })
);
function generateArrayList(key) {
  if (key === "Tài khoản") {
    return [
      { key: "IndexStudent", value: "Thông tin tài khoản" },
      { key: "ChangePassword", value: "Đổi mật khẩu" },
    ];
  } else if (key === "Đăng ký môn") {
    return [
      { key: "RegisterSubject", value: "Đăng ký" },
      { key: "RegisterSubject", value: "Môn đã đăng ký" },
    ];
  } else if (key === "Lịch") {
    return [
      { key: "subjects", value: "Môn học" },
      { key: "add", value: "Thêm" },
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
  const path = `/menu/${key}`;
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
  const location = useLocation();
  const [collapsed, setCollapsed] = useState(false);
  const [isContent, SetContent] = useState("");
  useEffect(() => {
    SetContent(location.pathname);
  }, [location]);
  return (
    <Layout>
      <Layout>
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
        <Layout style={{ padding: "0 24px 24px" }}>
          <Header style={{ padding: 0, background: colorBgContainer }}>
            <div style={{ display: "flex" }}>
              <Button
                type="text"
                icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
                onClick={() => setCollapsed(!collapsed)}
                style={{
                  fontSize: "16px",
                  width: 64,
                  height: 64,
                }}
              ></Button>
              <Breadcrumb style={{ margin: "16px 0", alignSelf: "center" }}>
                <Breadcrumb.Item>Home</Breadcrumb.Item>
                <Breadcrumb.Item>List</Breadcrumb.Item>
                <Breadcrumb.Item>App</Breadcrumb.Item>
              </Breadcrumb>
            </div>
          </Header>
          <Content
            style={{
              padding: "0 24px",
              margin: 0,
              minHeight: 280,
              background: colorBgContainer,
            }}
          >
            <Row>
              {isContent == "/RegisterSubject" ? (
                <RegisterSubject />
              ) : (
                <>
                  <Col span={12}>
                    <ImageInfomation />
                  </Col>
                  <Col span={12}>
                    {isContent === "/IndexStudent" ? (
                      <InfomationAccount />
                    ) : isContent === "/ChangePassword" ? (
                      <ChangePassword />
                    ) : (
                      isContent === "/rong"
                    )}{" "}
                  </Col>
                </>
              )}
            </Row>
          </Content>
        </Layout>
      </Layout>
    </Layout>
  );
};

export default IndexStudent;
