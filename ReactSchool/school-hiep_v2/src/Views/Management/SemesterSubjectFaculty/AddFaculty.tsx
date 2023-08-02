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
        <Form.Item name="NameFaculty" label="Tên khoa">
          <Input />
        </Form.Item>
        
        <Button type="primary" block onClick={handleSaveClick}>
            Add Faculty
        </Button> 
      </Form>

    </>
  );
};

export default () => <FormDisabledDemo />;