import React, { useState } from 'react';
import { LaptopOutlined, NotificationOutlined, UserOutlined,  MenuFoldOutlined, MenuUnfoldOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Breadcrumb, Layout, Menu, theme ,Button,Col, Row } from 'antd';
import InfomationAccount from "./InfomationAccount.tsx";
import ImageInfomation from "./ImageInfomation.tsx";


const { Header, Content, Sider } = Layout;

const items1: MenuProps['items'] = ['Tài khoản', 'Đăng ký môn', 'Lịch'].map((key, index) => ({
  key,
  label: `${key}`,
  ArrayList: generateArrayList(key),
}));  
function generateArrayList(key) {
  if (key === 'Tài khoản') {
    return [`Thông tin tài khoản`, `Đổi mật khẩu`,];
  } else if (key === 'Đăng ký môn') {
    return ['Đăng ký', 'Danh Môn'];
  } else  if (key === 'Lịch'){
    return ['Môn học', 'thêm'];
  }
}

const items2: MenuProps['items'] = [UserOutlined, LaptopOutlined, NotificationOutlined].map(
  (icon, index) => {
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
  },
);


const App: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
const [collapsed, setCollapsed] = useState(false);
  return (
    <Layout>

      <Layout>
        
        <Sider width={200} style={{ background: colorBgContainer }} trigger={null} collapsible collapsed={collapsed}>
          <Menu
            mode="inline"
            defaultSelectedKeys={['1']}
            defaultOpenKeys={['sub1']}
            style={{ height: '100%', borderRight: 0 }}
            items={items2}
          />
        </Sider>
        <Layout style={{ padding: '0 24px 24px' }}>
          <Header style={{ padding: 0, background: colorBgContainer }}>
          <Button
            type="text"
            icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
            onClick={() => setCollapsed(!collapsed)}
            style={{
              fontSize: '16px',
              width: 64,
              height: 64,
            }}
          />
        </Header>
          <Breadcrumb style={{ margin: '16px 0' }}>
            <Breadcrumb.Item>Home</Breadcrumb.Item>
            <Breadcrumb.Item>List</Breadcrumb.Item>
            <Breadcrumb.Item>App</Breadcrumb.Item>
          </Breadcrumb>
          <Content
            style={{
              padding: 24,
              margin: 0,
              minHeight: 280,
              background: colorBgContainer,
            }}
          >
            <Row>
              <Col span={12}>
                <ImageInfomation/>
              </Col>
              <Col span={12}>
                <InfomationAccount/>                
              </Col>
            </Row>
          </Content>
        </Layout>
      </Layout>
    </Layout>
  );
};

export default App;