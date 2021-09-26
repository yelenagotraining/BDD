//
//  ServiceLevel.swift
//  Globotickets
//
//  Created by Marko Vajs on 22.6.21..
//

import Foundation

struct ServiceLevel : Identifiable {
    var id = Int()
    var title = String()
    var price = Double()
    
    init(id: Int, title: String, price: Double) {
        self.id = id;
        self.title = title
        self.price = price
    }
}
