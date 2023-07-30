import SearchIcon from "@mui/icons-material/Search";
const SearchInput = () => {
  return (
    <div className="bg-gray-100 rounded-2xl flex gap-3 p-2">
      <SearchIcon />
      <input
        className="bg-gray-100 focus:outline-none"
        placeholder="Search Twitter"
      />
    </div>
  );
};

export default SearchInput;
