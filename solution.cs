Here's a JavaScript console application that computes the minimum spanning tree of a graph using Kruskal's algorithm:

```javascript
class UnionFind {
    constructor(elements) {
        this.count = elements.length;
        this.parent = {};
        elements.forEach(e => (this.parent[e] = e));
    }

    union(a, b) {
        let rootA = this.find(a);
        let rootB = this.find(b);
        if (rootA === rootB) return;
        if (rootA < rootB) {
            if (this.parent[b] != b) this.union(this.parent[b], a);
            this.parent[b] = this.parent[a];
        } else {
            if (this.parent[a] != a) this.union(this.parent[a], b);
            this.parent[a] = this.parent[b];
        }
    }

    find(a) {
        while (this.parent[a] !== a) {
            a = this.parent[a];
        }
        return a;
    }

    connected(a, b) {
        return this.find(a) === this.find(b);
    }
}

function kruskal(nodes, edges) {
    let unionFind = new UnionFind(nodes);
    let mst = [];
    edges.sort((a, b) => a[2] - b[2]);
    for (let i = 0; i < edges.length; i++) {
        let edge = edges[i];
        if (!unionFind.connected(edge[0], edge[1])) {
            unionFind.union(edge[0], edge[1]);
            mst.push(edge);
        }
    }
    return mst;
}

let nodes = ['A', 'B', 'C', 'D', 'E', 'F', 'G'];
let edges = [
    ['A', 'B', 7],
    ['A', 'D', 5],
    ['B', 'C', 8],
    ['B', 'D', 9],
    ['B', 'E', 7],
    ['C', 'E', 5],
    ['D', 'E', 15],
    ['D', 'F', 6],
    ['E', 'F', 8],
    ['E', 'G', 9],
    ['F', 'G', 11]
];

console.log(kruskal(nodes, edges));
```

This program first sorts the edges by weight, then iterates over them, adding each edge to the minimum spanning tree if it doesn't create a cycle (checked using the UnionFind data structure). The result is an array of edges that form the minimum spanning tree.