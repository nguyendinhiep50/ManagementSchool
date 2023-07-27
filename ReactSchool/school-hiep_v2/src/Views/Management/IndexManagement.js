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
import { useLocation } from "react-router-dom";
const { Header, Content, Sider } = Layout;

const items1: MenuProps["items"] = [
  "Tài khoản",
  "Quản lý học sinh",
  "Quản lý giảng viên",
  "Quản lý chương trình",
].map((key, index) => ({
  key,
  label: `${key}`,
  ArrayList: generateArrayList(key),
}));
function generateArrayList(key) {
  if (key === "Tài khoản") {
    return [
      { key: "IndexStudent", value: "Thông tin tài khoản" },
      { key: "ChangePassword", value: "Đổi mật khẩu" },
    ];
  } else if (key === "Quản lý học sinh") {
    return [
      { key: "IndexStudent", value: "Thêm học sinh" },
      { key: "ChangePassword", value: "Danh sách học sinh" },
    ];
  } else if (key === "Quản lý giảng viên") {
    return ["Thêm giảng viên", "Danh sách giảng viên"];
  } else if (key === "Quản lý chương trình") {
    return [
      "quản lý học kì",
      "quản lý lớp",
      "quản lý môn học",
      "quản lý khóa học",
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
        label: item,
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
  const [ChangePassword, setChangePassword] = useState(false);
  useEffect(() => {
    if (location.pathname == "/ChangePassword") {
      setChangePassword(true);
    } else {
      setChangePassword(false);
    }
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
          />
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
              <Col span={12}>
                {ChangePassword == false ? (
                  <InfomationAccount />
                ) : (
                  <ChangePassword />
                )}
              </Col>
            </Row>
          </Content>
        </Layout>
      </Layout>
    </Layout>
  );
};

export default IndexStudent;
