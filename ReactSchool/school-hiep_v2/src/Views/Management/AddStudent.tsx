import React, { useState } from 'react'; 
import { PlusOutlined } from '@ant-design/icons';
import {
  Button,
  Cascader,
  Checkbox,
  DatePicker,
  Form,
  Input,
  InputNumber,
  Radio,
  Select,
  Slider,
  Switch,
  TreeSelect,
  Upload,
  Col, Row,form
} from 'antd';


const { RangePicker } = DatePicker;
const { TextArea } = Input;

const normFile = (e: any) => {
  if (Array.isArray(e)) {
    return e;
  }
  return e?.fileList;
};

const FormDisabledDemo: React.FC = () => {
  const [form] = Form.useForm();
  const [componentDisabled, setComponentDisabled] = useState<boolean>(false);
  const [DataPost,setDataPost] = useState({ 
    NameStudent:"",
    ImageStudent:"",
    EmailStudent:"",
    PasswordStudent:"",
    BirthDateStudent:"",
    PhoneStudent:"",
    AdressStudent:"",
    SchoolYear:"",
    DateComeShoool:"",
    StatusStudent:"",
  });
  const handleSaveClick = async () => {

  };
  return (
    <>
      <Form
        form={form}
        labelCol={{ span: 4 }}
        wrapperCol={{ span: 14 }}
        layout="horizontal"
        style={{ maxWidth: 600 }}
      >
        <Form.Item name="NameStudent" label="Họ và tên">
          <Input />
        </Form.Item>
        <Form.Item name="" label="Khoa">
          <Select>
            <Select.Option value="demo">Demo</Select.Option>
          </Select>
        </Form.Item>
        <Form.Item name="EmailStudent" label="Email">
          <Input />
        </Form.Item>   
        <Form.Item name="SexStudent" label="Giới tính">
          <Radio.Group>
            <Radio value="Nam"> Nam </Radio>
            <Radio value="Nu"> Nữ </Radio>
          </Radio.Group>
        </Form.Item>        
        <Form.Item name="BirthDateStudent" label="Ngày sinh">
          <DatePicker />
        </Form.Item>
        <Form.Item name="PhoneStudent" label="Số điện thoại">
          <Input />
        </Form.Item>        
        <Form.Item name="AdressStudent" label="Địa chỉ">
          <Input />
        </Form.Item>
        <Form.Item name="ImageStudent" label="Thay đổi ảnh" valuePropName="fileList" getValueFromEvent={normFile}>
          <Upload action="/upload.do" listType="picture-card">
            <div>
              <PlusOutlined />
              <div style={{ marginTop: 8 }}>Upload</div>
            </div>
          </Upload>
        </Form.Item>
        <Button type="primary" block onClick={handleSaveClick}>
            Add Student
        </Button> 
      </Form>

    </>
  );
};

export default () => <FormDisabledDemo />;