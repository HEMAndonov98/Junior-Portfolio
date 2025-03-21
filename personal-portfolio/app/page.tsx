'use client'
import Benefits from "@/components/Benefits";
import Education from "@/components/Education";
import Experience from "@/components/Experience";
import Grid from "@/components/grid";
import Hero from "@/components/Hero";
import RecentProjects from "@/components/RecentProjects";

export default function Home() {
  return (
    <main className="relative bg-black-100 flex justify-center items-center flex-col overflow-hidden
    mx-auto sm:px-10 px-5">
      <div className="max-w-7xl w-full">
        <Hero />
        <Grid />
        <RecentProjects />
        <Benefits />
        <Experience />
        <Education />
      </div>
    </main>
  );
}
