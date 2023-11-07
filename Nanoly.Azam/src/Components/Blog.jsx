const Blog = ({ properties }) => {
  const { id, nameOfBlog } = properties;
  return (
    <>
      <section
        style={{
          justifyContent: "center",
          alignItems: "center",
          height: "100vh",
          width: "100vw",
          fontSize: 25,
        }}
      >
        <h1 style={{ color: "darkblue", margin: "2rem", textAlign: "center" }}>
          {" "}
          Id of the Blog is : {id}
        </h1>
        <h1 style={{ color: "darkblue", margin: "2rem", textAlign: "center" }}>
          {" "}
          Name of the Blog is :{nameOfBlog}
        </h1>
      </section>
    </>
  );
};
export default Blog;
