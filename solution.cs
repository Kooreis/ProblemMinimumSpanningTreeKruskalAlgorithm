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