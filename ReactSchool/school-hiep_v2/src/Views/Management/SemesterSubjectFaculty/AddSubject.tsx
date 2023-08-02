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
  Col, Row
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
  const [componentDisabled, setComponentDisabled] = useState<boolean>(false);

  return (
    <>
      <Form
        labelCol={{ span: 4 }}
        wrapperCol={{ span: 14 }}
        layout="horizontal"
        style={{ maxWidth: 600 }}
      >
        <Form.Item label="Tên môn">
          <Input />
        </Form.Item>
        <Form.Item label="Chứng chỉ">
          <Input />
        </Form.Item>   
        <Form.Item label="Loại môn">
              <Radio.Group>
                <Radio value="Mandatory"> Bắt buộc </Radio>
                <Radio value="NoMandatory"> Không bắt buộc </Radio>
              </Radio.Group>
        </Form.Item>   
        
        <Button type="primary" block>
            Add Subject
        </Button> 
      </Form>

    </>
  );
};

export default () => <FormDisabledDemo />;