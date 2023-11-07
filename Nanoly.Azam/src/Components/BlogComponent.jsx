import { useParams } from "react-router-dom";
import blogs from "../utils/constants";
import Blog from "./Blog";

const BlogComponent = () => {
  const { id } = useParams();
  const blog = blogs.filter((blog) => blog.id === Number(id));
  return (
    <>
      <Blog properties={blog[0]} />
    </>
  );
};
export default BlogComponent;
