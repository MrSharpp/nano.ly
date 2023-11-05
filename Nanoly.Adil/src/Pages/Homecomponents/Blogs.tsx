//import React from 'react'
import { useParams } from 'react-router-dom';


function Blogs() {

    const { id } = useParams();
    const blogData = [
        { id: 1,  content: "Hi, My name is Adil I am React Frontend Developer under the supervision of Amir" },
        { id: 2, content: "Hi, My name is Amir and I am a Full Stack Developer" },
        { id: 3,  content: "Hi, My name is Shams and I am a Front-end Developer" },
        { id: 4,  content: "Hi, My name is Ahmad and I am a Full Stack Developer" },
    ];

    const selectBlog = blogData.find(blog => blog.id.toString() === id); 
  return (
   
    <div>
    <div>
    <p className="tittle" style={{textAlign:"center",fontSize:"60px",fontWeight:"bold"}}>Blog !</p>
    <p className="content"style={{textAlign:"center",fontSize:"40px"}}>
    {selectBlog ? selectBlog.content :null}
    </p>
    </div>
     </div>
    
  )
}

export default Blogs