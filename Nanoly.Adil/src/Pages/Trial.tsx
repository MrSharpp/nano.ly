import React, { useState } from 'react';
function Trial() {
    const [data, setData] = useState({
        username:'',
        firstName:'',
        lastName:'',
        email: '',
});
const handleInputChange =(e:any)=>{
   const {name,value} = e.target;
   setData({
     ...data,
     [name]: value
   })
}
 const handleSubmit = (e:React.FormEvent) =>{
  e.preventDefault();
 }
    return (
        <div className='form'>
    <form onSubmit={handleSubmit}
    style={{alignItems:"center",display:"flex",justifyContent:"center",marginTop:"50px"}}>
    <label >Username
      <input
        type="text"
        name="username"
        value={data.username}
        onChange={handleInputChange}
      />
    </label>
    <br />
    <label>
    FirstName
      <input
        type="text"
        name="firstName"
        value={data.firstName}
        onChange={handleInputChange}
      />
      </label>

      <label>
      LastName
      <input
        type="text"
        name="lastName"
        value={data.lastName}
        onChange={handleInputChange}
      />
       <label>
       Email
      <input
        type="text"
        name="email"
        value={data.email}
        onChange={handleInputChange}
      />
      </label>
      </label>
      </form>
      </div>
      )
}

export default Trial