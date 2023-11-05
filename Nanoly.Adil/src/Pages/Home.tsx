import { useNavigate } from "react-router-dom";

function Home() {

  const blogData = [
    {id:1, name: "Adil Blogs",},
    {id:2,   name: "Amir Blogs",   },
    { id:3, name: "Shams Blogs", },
    { id:4, name: "Ahmad Blogs",},
  ];  
  const navigate = useNavigate();
  const handleBlogClick = (id:number ) => {
    navigate(`/blog/${id}`);
  };
  return (
   <div className="home" style={{ display: "flex", gap: "40px", marginTop: "40px", justifyContent: "center", fontSize: "30px", backgroundColor: "lightblue" }}>
    {blogData.map((blog, index) => (
      <div className="blog-list" key={index}>
        <span className="blog-item" style={{ cursor: "grab" }}  onClick={() => handleBlogClick(blog.id)}>{blog.name}</span>
        </div>
      ))}
    </div>

  );
}

export default Home;


