const BlogComponent = (props) => {
  const {
    properties: { id, nameOfBlog },
  } = props;
  return (
    <>
      <h1>Id of Blog is : {id}</h1>
      <h1>Name of the Blog is : {nameOfBlog}</h1>
    </>
  );
};
export default BlogComponent;
