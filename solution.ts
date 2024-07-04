Here is a TypeScript console application that computes the minimum spanning tree of a graph using Kruskal's algorithm:

```typescript
class Edge {
    source: number;
    destination: number;
    weight: number;

    constructor(source: number, destination: number, weight: number) {
        this.source = source;
        this.destination = destination;
        this.weight = weight;
    }
}

class Graph {
    vertices: number;
    edges: Edge[];

    constructor(vertices: number) {
        this.vertices = vertices;
        this.edges = [];
    }

    addEdge(source: number, destination: number, weight: number) {
        this.edges.push(new Edge(source, destination, weight));
    }

    find(parent: number[], i: number): number {
        if (parent[i] === i) {
            return i;
        }
        return this.find(parent, parent[i]);
    }

    union(parent: number[], rank: number[], x: number, y: number) {
        let xroot = this.find(parent, x);
        let yroot = this.find(parent, y);

        if (rank[xroot] < rank[yroot]) {
            parent[xroot] = yroot;
        } else if (rank[xroot] > rank[yroot]) {
            parent[yroot] = xroot;
        } else {
            parent[yroot] = xroot;
            rank[xroot]++;
        }
    }

    kruskalMST() {
        let result: Edge[] = [];
        let i = 0;
        let e = 0;
        this.edges.sort((a, b) => a.weight - b.weight);
        let parent: number[] = [];
        let rank: number[] = [];

        for (let v = 0; v < this.vertices; ++v) {
            parent[v] = v;
            rank[v] = 0;
        }

        while (e < this.vertices - 1) {
            let next_edge = this.edges[i++];
            let x = this.find(parent, next_edge.source);
            let y = this.find(parent, next_edge.destination);

            if (x !== y) {
                result[e++] = next_edge;
                this.union(parent, rank, x, y);
            }
        }

        console.log("Following are the edges in the constructed MST");
        for (i = 0; i < e; ++i) {
            console.log(`${result[i].source} -- ${result[i].destination} == ${result[i].weight}`);
        }
    }
}

let g = new Graph(4);
g.addEdge(0, 1, 10);
g.addEdge(0, 2, 6);
g.addEdge(0, 3, 5);
g.addEdge(1, 3, 15);
g.addEdge(2, 3, 4);
g.kruskalMST();
```

This program creates a graph with 4 vertices and adds 5 edges to it. Then it computes the minimum spanning tree using Kruskal's algorithm and prints the edges of the minimum spanning tree.