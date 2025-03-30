export const getImagePath = (path: string): string => {
  //Check for empty path
  if(path == ""){
    return ""
  }

  // For GitHub Pages deployment
  const basePath = process.env.NODE_ENV === 'production' ? '/Junior-Portfolio' : '';
  
  // Make sure the path starts with a slash
  const normalizedPath = path.startsWith('/') ? path : `/${path}`;
  
  return `${basePath}${normalizedPath}`;
};

export const navItems = [
  { name: "About", link: "#about" },
  { name: "Projects", link: "#projects" },
  { name: "Testimonials", link: "#testimonials" },
  { name: "Contact", link: "#contact" },
];

export const gridItems = [
  {
    id: 1,
    title: "Building, learning, and evolving with technology",
    description: "",
    className: "lg:col-span-3 md:col-span-6 md:row-span-4 lg:min-h-[60vh]",
    imgClassName: "w-full h-full",
    titleClassName: "justify-end",
    img: getImagePath("/b1.svg"),
    spareImg: getImagePath(""),
  },
  {
    id: 2,
    title: "I'm very flexible with time zone communications",
    description: "",
    className: "lg:col-span-2 md:col-span-3 md:row-span-2",
    imgClassName: "",
    titleClassName: "justify-start",
    img: getImagePath(""),
    spareImg: getImagePath(""),
  },
  {
    id: 3,
    title: "My tech stack",
    description: "I constantly try to improve",
    className: "lg:col-span-2 md:col-span-3 md:row-span-2",
    imgClassName: "",
    titleClassName: "justify-center",
    img: getImagePath(""),
    spareImg: getImagePath(""),
  },
  {
    id: 4,
    title: "Problem solver with a passion for web development.",
    description: "",
    className: "lg:col-span-2 md:col-span-3 md:row-span-1",
    imgClassName: "",
    titleClassName: "justify-start",
    img: getImagePath("/grid.svg"),
    spareImg: getImagePath("/b4.svg"),
  },

  {
    id: 5,
    title: "Currently graduating SoftUni Web Developer path",
    description: "The Inside Scoop",
    className: "md:col-span-3 md:row-span-2",
    imgClassName: "absolute right-0 bottom-0 md:w-96 w-60",
    titleClassName: "justify-center md:justify-start lg:justify-cente",
    img: getImagePath("/b5.svg"),
    spareImg: getImagePath("/grid.svg"),
  },
  {
    id: 6,
    title: "Do you want to start a project together?",
    description: "",
    className: "lg:col-span-2 md:col-span-3 md:row-span-1",
    imgClassName: "",
    titleClassName: "justify-center md:max-w-full max-w-60 text-center",
    img: getImagePath(""),
    spareImg: getImagePath(""),
  },
];

export const projects = [
  {
    id: 1,
    title: "Personal Blog Hristos Dev Adventures",
    des: "Built a personal blog to record interesting things I find relating to tech using jekyll SSG and heavily modified css from scratch with modified styles",
    img: getImagePath("/blog-project.png"),
    iconLists: [getImagePath("/html5.svg"), getImagePath("/js.svg"), getImagePath("/jekyll.svg"), getImagePath("/css.svg")],
    link: "https://github.com/HEMAndonov98/HTML-CSS-May-2024/tree/main/Workshop/hristos-dev-adventures",
  },
  {
    id: 2,
    title: "CustomDiFramework",
    des: "Created a dependeny injection framework from scratch to better understand how it works under the hood",
    img: getImagePath("/DiFrameworkImage.png"),
    iconLists: [getImagePath("/CSharpIcon.svg"), getImagePath("/NETcore.svg")],
    link: "https://github.com/adrianhajdin/zoom-clone",
  },
  {
    id: 3,
    title: "Console Snake game",
    des: "Take a break from the endless coding and problem solving, and enjoy some snake",
    img: getImagePath("/SnakeProject.png"),
    iconLists: [getImagePath("/CSharpIcon.svg"), getImagePath("/NETcore.svg")],
    link: "https://github.com/HEMAndonov98/SoftUni-C-Sharp-OOP/tree/master/Simple%20Snake%20Workshop/SimpleSnake",
  },
  {
    id: 4,
    title: "Web Chat Application",
    des: "Web based chat application with a sleek and intuitive UI",
    img: getImagePath("/p4.svg"),
    iconLists: [getImagePath("/next.svg"), getImagePath("/tail.svg"), getImagePath("/ts.svg"), getImagePath("/NETcore.svg"), getImagePath("/postgresql.svg")],
    link: "https://github.com/adrianhajdin/iphone",
  },
];

// export const testimonials = [
//   {
//     quote:
//       "Collaborating with Adrian was an absolute pleasure. His professionalism, promptness, and dedication to delivering exceptional results were evident throughout our project. Adrian's enthusiasm for every facet of development truly stands out. If you're seeking to elevate your website and elevate your brand, Adrian is the ideal partner.",
//     name: "Michael Johnson",
//     title: "Director of AlphaStream Technologies",
//   },
//   {
//     quote:
//       "Collaborating with Adrian was an absolute pleasure. His professionalism, promptness, and dedication to delivering exceptional results were evident throughout our project. Adrian's enthusiasm for every facet of development truly stands out. If you're seeking to elevate your website and elevate your brand, Adrian is the ideal partner.",
//     name: "Michael Johnson",
//     title: "Director of AlphaStream Technologies",
//   },
//   {
//     quote:
//       "Collaborating with Adrian was an absolute pleasure. His professionalism, promptness, and dedication to delivering exceptional results were evident throughout our project. Adrian's enthusiasm for every facet of development truly stands out. If you're seeking to elevate your website and elevate your brand, Adrian is the ideal partner.",
//     name: "Michael Johnson",
//     title: "Director of AlphaStream Technologies",
//   },
//   {
//     quote:
//       "Collaborating with Adrian was an absolute pleasure. His professionalism, promptness, and dedication to delivering exceptional results were evident throughout our project. Adrian's enthusiasm for every facet of development truly stands out. If you're seeking to elevate your website and elevate your brand, Adrian is the ideal partner.",
//     name: "Michael Johnson",
//     title: "Director of AlphaStream Technologies",
//   },
//   {
//     quote:
//       "Collaborating with Adrian was an absolute pleasure. His professionalism, promptness, and dedication to delivering exceptional results were evident throughout our project. Adrian's enthusiasm for every facet of development truly stands out. If you're seeking to elevate your website and elevate your brand, Adrian is the ideal partner.",
//     name: "Michael Johnson",
//     title: "Director of AlphaStream Technologies",
//   },
// ];

export const testimonials = [
  {
    title: "Fun and Charismatic",
    quote: "Your office will be filled with laughter, whether it's at my jokes or at my code. Either way, team morale is guaranteed to skyrocket (or at least hit terminal velocity)."
  },
  {
    title: "If It Ain't Broke, I'll Break It",
    quote: "A well-functioning codebase is a great start—but can it be better? I'll refactor, debug, and push it to its limits until it's unrecognizable… in a good way. Trust me, it’ll work better when I’m done (eventually)."
  },
  {
    title: "Readable Code > Good Looks",
    quote: "Some developers write code. I write bedtime stories for compilers. Clear, structured, and so easy to read, even your grandma will understand what a dependency injection is (probably)."
  },
  {
    title: "Test-Driven Development... Kinda",
    quote: "I write tests. Not always first, but definitely after something breaks. If debugging is the process of removing bugs, then I am a prolific bug producer, ensuring my code is thoroughly battle-tested."
  },
  {
    title: "Stack Overflow Enthusiast",
    quote: "I may not know everything, but I sure know where to find it! From Stack Overflow to documentation deep dives, I wield the power of Ctrl+C and Ctrl+V with precision, backed by actual understanding (most of the time)."
  }
];


// export const companies = [
//   {
//     id: 1,
//     name: "cloudinary",
//     img: getImagePath("/cloud.svg"),
//     nameImg: "/cloudName.svg",
//   },
//   {
//     id: 2,
//     name: "appwrite",
//     img: getImagePath("/app.svg"),
//     nameImg: "/appName.svg",
//   },
//   {
//     id: 3,
//     name: "HOSTINGER",
//     img: getImagePath("/host.svg"),
//     nameImg: "/hostName.svg",
//   },
//   {
//     id: 4,
//     name: "stream",
//     img: getImagePath("/s.svg"),
//     nameImg: "/streamName.svg",
//   },
//   {
//     id: 5,
//     name: "docker.",
//     img: getImagePath("/dock.svg"),
//     nameImg: "/dockerName.svg",
//   },
// ];

export const workExperience = [
  {
  id: 1,
  title: "Languages",
  technology: [
    { name: "JavaScript", level: 8 },
    { name: "C#", level: 7 },
    { name: "TypeScript", level: 6 },
    { name: "SQL", level: 6 }, 
    { name: "HTML", level: 9 },
    { name: "CSS", level: 8 }
  ],
  className: "md:col-span-2",
},
  {
  id: 2,
  title: "Frameworks & Libraries",
  technology: [
    { name: "ASP.NET Core", level: 7 },
    { name: "ASP.NET MVC", level: 6 },
    { name: "Entity Framework Core", level: 6 },
    { name: "SignalR", level: 5 },
    { name: "Next.js", level: 5 },
    { name: "React", level: 5 },
    { name: "Node.js", level: 5 },
  ],
  className: "md:col-span-2",
},
{
  id: 4,
  title: "Databases & Storage",
  technology: [
    { name: "MSSQL", level: 7 },
    { name: "PostgreSQL", level: 6 },
    { name: "MySQL", level: 6 },
    { name: "SQLite", level: 5 },
    { name: "Supabase", level: 5 },
  ],
  className: "md:col-span-2",
},
{
  id: 5,
  title: "Concepts & Methodologies",
  technology: [
    { name: "Object-Oriented Programming", level: 8 },
    { name: "Data Structures & Algorithms", level: 7 },
    { name: "RESTful APIs", level: 7 },
    { name: "Authentication & Security", level: 6 },
    { name: "Software Design Patterns", level: 5 },
  ],
  className: "md:col-span-2",
},
];

export const socialMedia = [
  {
    id: 1,
    img: getImagePath("/git.svg"),
    link: "https://github.com/HEMAndonov98",
  },
  {
    id: 2,
    img: getImagePath("/insta.svg"),
    link: "https://www.instagram.com/nottherealhristo/",
  },
  {
    id: 3,
    img: getImagePath("/link.svg"),
    link: "www.linkedin.com/in/hristo-e-andonov",
  },
];