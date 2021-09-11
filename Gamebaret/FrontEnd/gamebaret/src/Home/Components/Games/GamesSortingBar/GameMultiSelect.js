import React, { Component } from 'react'
import Select from 'react-select'
import { useState } from 'react';

const customStyles = {
  control: base => ({
    ...base,
    height: 45
  })
};

function GameMultiSelect(props){
  const options = props.values.map(e => {return { value:e.id , label:e.name}} );
  let handleChange = (e) => {
      let values = Array.from(e, option => option.value);
      props.onChange(values);
  }
  return (
      <Select
          styles={customStyles}
          className="w-100"
          defaultValue={[]}
          isMulti
          name="colors"
          options={options}
          className="basic-multi-select"
          classNamePrefix="select"
          placeholder={props.placeholder}
          onChange={handleChange}
      />
  );
}

export default GameMultiSelect;