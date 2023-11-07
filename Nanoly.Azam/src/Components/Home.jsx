import { Link } from "react-router-dom";
import blogs from "../utils/constants";
const Home = () => {
  return (
    <>
      <h1
        style={{
          textAlign: "center",
          marginBottom: "1rem",
          color: "brown",
          fontStyle: "italic",
          fontSize: 35,
        }}
      >
        List Of Blogs!
      </h1>
      <div style={{ padding: "2rem", display: "flex", gap: "3rem" }}>
        {blogs.map(function (blog) {
          return (
            <h1
              key={blog.id}
              style={{
                textAlign: "center",
                marginBottom: "2rem",
                border: "2px solid black",
                padding: "1rem",
                borderRadius: "10px",
              }}
            >
              <Link to={"/blog/" + blog.id} style={{ textDecoration: "none" }}>
                {blog.nameOfBlog}
              </Link>
            </h1>
          );
        })}
      </div>
    </>
  );
};
export default Home;
