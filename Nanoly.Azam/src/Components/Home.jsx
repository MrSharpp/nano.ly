import { Link } from "react-router-dom";
import blogs from "../utils/constants";
const Home = () => {
  return (
    <>
      <h1>List Of Blogs!</h1>
      {blogs.map(function (blog) {
        return (
          <h1 key={blog.id}>
            <Link to={blog.id}>{blog.nameOfBlog}</Link>
          </h1>
        );
      })}
    </>
  );
};
export default Home;
