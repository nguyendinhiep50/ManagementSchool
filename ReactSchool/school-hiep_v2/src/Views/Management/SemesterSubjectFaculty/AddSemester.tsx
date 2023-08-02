import React, { useState } from 'react'; 
import { PlusOutlined } from '@ant-design/icons';
import {
  Button,
  DatePicker,
  Form,
  Input,
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
        <Form.Item name="NameStudent" label="Tên học">
          <Input />
        </Form.Item>

        <Form.Item name="EmailStudent" label="Email">
          <Input />
        </Form.Item>   
    
        <Form.Item name="BirthDateStudent" label="Ngày bắt đầu">
          <DatePicker />
        </Form.Item>
        <Form.Item name="BirthDateStudent" label="Ngày kết thúc">
          <DatePicker />
        </Form.Item>       
        <Button type="primary" block onClick={handleSaveClick}>
            Add Semester
        </Button> 
      </Form>

    </>
  );
};

export default () => <FormDisabledDemo />;