import React, { useState } from 'react'
import Constants from '../utilities/Constant'

export default function PostCreateForm(props) {

  const initialFormData = Object.freeze({
    title: "Post x",
    content: "this is post x"
  });
  const [formData, setformData] = useState(initialFormData);

  

  const handleChange = (e) =>{
    setformData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e)=>{
    e.preventDefault();

    const postToCreate = {
      postId: 0,
      title: formData.title,
      content: formData.content
    };

    const url = Constants.API_URL_CREATE_POST;

    fetch(url, {
      method: 'POST',
      headers:{
        'Content-type': 'application/json'
      },
      body: JSON.stringify(postToCreate)
    })
      .then(Response => Response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

      props.onPostCreated(postToCreate);
  };

  return (
    <form className='w-100 px-5'>
        <h1 className='mt-5'>Create New Post</h1>

        <div className='mt-5'>
          <label className='h3 form-label'>Post Title</label>
          <input value={formData.title} name="title" type='text' className='form-control' onChange={handleChange} />
        </div>

        <div className='mt-4'>
          <label className='h3 form-label'>Post content</label>
          <input value={formData.content} name="content" type='text' className='form-control' onChange={handleChange} />
        </div>

        <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
        <button onClick={()=>props.onPostCreated(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
      </form>
  );
}